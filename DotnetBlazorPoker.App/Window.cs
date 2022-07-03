using Microsoft.JSInterop;

namespace DotnetBlazorPoker.App
{
    public static class Window
    {
        private static IJSObjectReference _windowHelpersModule;
        private static IJSInProcessObjectReference _windowHelpersModulesInProcess;

        /// <summary>
        /// Initializes the underlying modules with the given IJSRuntime instance
        /// </summary>
        /// <param name="jsRuntime">The IJSRuntime instance</param>
        public static async Task Initialize(IJSRuntime jsRuntime)
        {
            _windowHelpersModule = await jsRuntime.InvokeAsync<IJSObjectReference>("import", "././scripts/windowHelpers.js");

            _windowHelpersModulesInProcess = (IJSInProcessObjectReference)_windowHelpersModule;
        }

        /// <summary>
        /// Tests whether the document matches the given media query.
        /// </summary>
        /// <param name="mediaQuery">The media query to be tested</param>
        /// <returns>True if the media query matches; False otherwise</returns>
        public static bool MatchMedia(string mediaQuery)
        {
            return _windowHelpersModulesInProcess.Invoke<bool>("matchMedia", mediaQuery);
        }

        /// <summary>
        /// Tests whether the document matches the given media query.
        /// </summary>
        /// <param name="mediaQuery">The media query to be tested</param>
        /// <returns>True if the media query matches; False otherwise</returns>
        public static async Task<bool> MatchMediaAsync(string mediaQuery)
        {
            return await _windowHelpersModule.InvokeAsync<bool>("matchMedia", mediaQuery);
        }
    }
}
