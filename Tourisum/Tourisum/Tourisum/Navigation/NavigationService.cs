using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Tourisum.View;
using Xamarin.Forms;

namespace Tourisum.Navigation
{
    public class NavigationService : INavigationService
    {
        private readonly object _sync = new object();
        private readonly Dictionary<string, Type> _pagesByKey = new Dictionary<string, Type>();
        private readonly Stack<NavigationPage> _navigationPageStack = new Stack<NavigationPage>();

        private NavigationPage CurrentNavigationPage => _navigationPageStack.Peek();
        private string currentPageKey = null;
        private bool goback = false;

        private Dictionary<string, Type> _pages = new Dictionary<string, Type>
        {
            {"HomePage", typeof(HomePage)},
            {"RegisterPage", typeof(RegisterPage) },
            {"SignInPage", typeof(SignInPage) },
        };

        public void Configure(string pageKey, Type pageType)
        {
            try
            {
                lock (_sync)
                {
                    if (_pagesByKey.ContainsKey(pageKey))
                    {
                        _pagesByKey[pageKey] = pageType;
                    }
                    else
                    {
                        _pagesByKey.Add(pageKey, pageType);
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        public Page SetRootPage(string rootPageKey)
        {
            try
            {
                var rootPage = GetPage(rootPageKey);
                _navigationPageStack.Clear();
                var mainPage = new NavigationPage(rootPage);
                _navigationPageStack.Push(mainPage);
                return mainPage;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private Page GetPage(string pageKey, object parameter = null)
        {
            try
            {
                lock (_sync)
                {
                    if (!_pagesByKey.ContainsKey(pageKey))
                    {
                        throw new ArgumentException(
                            $"No such page: {pageKey}. Did you forget to call NavigationService.Configure?");
                    }

                    var type = _pagesByKey[pageKey];

                    ConstructorInfo constructor;
                    object[] parameters;

                    if (parameter == null)
                    {
                        constructor = type.GetTypeInfo()
                            .DeclaredConstructors
                            .FirstOrDefault(c => !c.GetParameters().Any());

                        parameters = new object[]
                        {
                        };
                    }
                    else
                    {
                        constructor = type.GetTypeInfo()
                            .DeclaredConstructors
                            .FirstOrDefault(
                                c =>
                                {
                                    var p = c.GetParameters();
                                    return p.Length == 1
                                           && p[0].ParameterType == parameter.GetType();
                                });

                        parameters = new object[]
                        {
                    parameter
                    };
                    }

                    if (constructor == null)
                    {
                        throw new InvalidOperationException(
                            "No suitable constructor found for page " + pageKey);
                    }

                    var page = constructor.Invoke(parameters) as Page;

                    return page;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string CurrentPageKey
        {
            get
            {
                lock (_sync)
                {
                    if (CurrentNavigationPage?.CurrentPage == null)
                    {
                        return null;
                    }

                    var pageType = CurrentNavigationPage.CurrentPage.GetType();

                    return _pagesByKey.ContainsValue(pageType)
                        ? _pagesByKey.First(p => p.Value == pageType).Key
                        : null;
                }
            }
        }

        public async Task PopModalAsync()
        {
            if (_navigationPageStack.Count > 1)
            {
                if (goback)
                {
                    goback = false;
                    _navigationPageStack.Pop();
                    await CurrentNavigationPage.Navigation.PopModalAsync();

                    Device.StartTimer(new TimeSpan(0, 0, 2), () =>
                    {
                        goback = true;
                        return false;
                    });
                }

                else
                {
                    return;
                }
            }
        }

        public async Task PushModalAsync(string pageKey, bool animated)
        {
            await PushModalAsync(pageKey, null, animated);
        }

        public async Task PushModalAsync(string pageKey, object parameter = null, bool animated = true)
        {
            var page = GetPage(pageKey, parameter);
            NavigationPage.SetHasNavigationBar(page, false);
            var modalNavigationPage = new NavigationPage(page);
            currentPageKey = pageKey;
            if (App.NavigationService.CurrentPageKey != currentPageKey)
            {
                await CurrentNavigationPage.Navigation.PushModalAsync(modalNavigationPage, animated);
                _navigationPageStack.Push(modalNavigationPage);
            }
        }

        public async Task PushAsync(string pageKey, bool animated)
        {
            await PushAsync(pageKey, null, animated);
        }

        public async Task PushAsync(string pageKey, object parameter = null, bool animated = true)
        {
            var pageType = _pages.ContainsKey(pageKey) ? _pages[pageKey] : null; //GetPage(pageKey, parameter);
            if (pageType == null) return;
            var page = Activator.CreateInstance(pageType) as Page;
            currentPageKey = pageKey;
            await App.Current.MainPage.Navigation.PushAsync(page, animated);
        }

        public async Task PopAsync(bool animated)
        {
            var navigationStack = CurrentNavigationPage.Navigation;
            if (navigationStack.NavigationStack.Count > 1)
            {
                if (goback)
                {
                    goback = false;
                    await CurrentNavigationPage.PopAsync();

                    Device.StartTimer(new TimeSpan(0, 0, 2), () =>
                    {
                        goback = true;
                        return false;
                    });

                }
                else
                {
                    return;
                }

            }
        }
    }
}
