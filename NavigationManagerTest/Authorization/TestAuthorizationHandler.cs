using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace NavigationManagerTest.Authorization
{
    public class TestAuthorizationHandler : AuthorizationHandler<TestAuthorizationRequirement>
    {
        private readonly NavigationManager _navigationManager;

        public TestAuthorizationHandler(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, TestAuthorizationRequirement requirement)
        {
            // If navigation happens internally and from links on the page, the navigation manager is initialized properly and retrieving the URI works fine.
            // However, if the URL bar is manipulated manually or the page is refreshed by the user, the navigation manager is never initialized, and throws an exception when hitting EnsureInitialized when attempting to get the URI.

            // should break here if the URL is manually entered instead of routing through the app
            string _uri = this._navigationManager.Uri;

            // Don't really care what happens
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
