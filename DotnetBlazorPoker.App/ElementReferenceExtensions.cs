using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace DotnetBlazorPoker.App
{
    /// <summary>
    /// Contains extension methods for the ElementReference interface
    /// </summary>
    public static class ElementReferenceExtensions
    {
        private static IJSObjectReference _elementHelpersModule;
        private static IJSInProcessObjectReference _elementHelpersModulesInProcess;
        
        /// <summary>
        /// Initializes the underlying modules with the given IJSRuntime instance
        /// </summary>
        /// <param name="jsRuntime">The IJSRuntime instance</param>
        public static async Task Initialize(IJSRuntime jsRuntime)
        {
            _elementHelpersModule = await jsRuntime.InvokeAsync<IJSObjectReference>("import", "././scripts/elementHelpers.js");

            _elementHelpersModulesInProcess = (IJSInProcessObjectReference)_elementHelpersModule;
        }

        /// <summary>
        /// Sets focus to the given element
        /// </summary>
        /// <param name="element">The element to be focused</param>
        public static void SetFocus(this ElementReference element)
        {
            _elementHelpersModulesInProcess.InvokeVoid("setFocus", element);
        }

        /// <summary>
        /// Sets focus to the given element
        /// </summary>
        /// <param name="element">The element to be focused</param>
        public static async Task SetFocusAsync(this ElementReference element)
        {
            await _elementHelpersModule.InvokeVoidAsync("setFocus", element);
        }

        /// <summary>
        /// Gets the property of the given element that matches the given name
        /// </summary>
        /// <typeparam name="T">The expected value of the property</typeparam>
        /// <param name="element">The element whose property is to be retrieved</param>
        /// <param name="property">The property to be retrieved</param>
        /// <returns>The value of the given property</returns>
        public static T GetProperty<T>(this ElementReference element, string property)
        {
            return _elementHelpersModulesInProcess.Invoke<T>("getProperty", element, property);
        }

        /// <summary>
        /// Gets the property of the given element that matches the given name
        /// </summary>
        /// <typeparam name="T">The expected value of the property</typeparam>
        /// <param name="element">The element whose property is to be retrieved</param>
        /// <param name="property">The property to be retrieved</param>
        /// <returns>The value of the given property</returns>
        public static async Task<T> GetPropertyAsync<T>(this ElementReference element, string property)
        {
           return await _elementHelpersModule.InvokeAsync<T>("getProperty", element, property);
        }

        /// <summary>
        /// Sets the property of the given element to the given value
        /// </summary>
        /// <param name="element">The element whose property is to be set</param>
        /// <param name="property">The property to be set</param>
        /// <param name="value">The value to be assigned</param>
        public static void SetProperty(this ElementReference element, string property, string value)
        {
            _elementHelpersModulesInProcess.InvokeVoid("setProperty", element, property, value);
        }

        /// <summary>
        /// Sets the property of the given element to the given value
        /// </summary>
        /// <param name="element">The element whose property is to be set</param>
        /// <param name="property">The property to be set</param>
        /// <param name="value">The value to be assigned</param>
        public static async Task SetPropertyAsync(this ElementReference element, string property, string value)
        {
            await _elementHelpersModule.InvokeVoidAsync("setProperty", element, property, value);
        }

        /// <summary>
        /// Gets the style of the given element that matches the given property
        /// </summary>
        /// <typeparam name="T">The expected value of the style</typeparam>
        /// <param name="element">The element whose style is to be retrieved</param>
        /// <param name="property">The property to be retrieved</param>
        /// <returns>The value of the property</returns>
        public static T GetStyle<T>(this ElementReference element, string property)
        {
            return _elementHelpersModulesInProcess.Invoke<T>("getStyle", element, property);
        }

        /// <summary>
        /// Gets the style of the given element that matches the given property
        /// </summary>
        /// <typeparam name="T">The expected value of the style</typeparam>
        /// <param name="element">The element whose style is to be retrieved</param>
        /// <param name="property">The property to be retrieved</param>
        /// <returns>The value of the property</returns>
        public static async Task<T> GetStyleAsync<T>(this ElementReference element, string property)
        {
            return await _elementHelpersModule.InvokeAsync<T>("getStyle", element, property);
        }

        /// <summary>
        /// Sets the style of the given element to the given value
        /// </summary>
        /// <param name="element">The element whose style is to be set</param>
        /// <param name="property">The property to be set</param>
        /// <param name="value">The value to be assigned</param>
        public static void SetStyle(this ElementReference element, string property, string value)
        {
            _elementHelpersModulesInProcess.InvokeVoid("setStyle", element, property, value);
        }

        /// <summary>
        /// Sets the style of the given element to the given value
        /// </summary>
        /// <param name="element">The element whose style is to be set</param>
        /// <param name="property">The property to be set</param>
        /// <param name="value">The value to be assigned</param>
        public static async Task SetStyleAsync(this ElementReference element, string property, string value)
        {
            await _elementHelpersModule.InvokeVoidAsync("setStyle", element, property, value);
        }

        /// <summary>
        /// Adds a class to the given element
        /// </summary>
        /// <param name="element">The element to be given a class</param>
        /// <param name="className">The name of the class to be added</param>
        public static void AddClass(this ElementReference element, string className)
        {
            _elementHelpersModulesInProcess.InvokeVoid("addClass", element, className);
        }

        /// <summary>
        /// Adds a class to the given element
        /// </summary>
        /// <param name="element">The element to be given a class</param>
        /// <param name="className">The name of the class to be added</param>
        public static async Task AddClassAsync(this ElementReference element, string className)
        {
            await _elementHelpersModule.InvokeVoidAsync("addClass", element, className);
        }

        /// <summary>
        /// Removes a class to the given element
        /// </summary>
        /// <param name="element">The element whose class is to be removed</param>
        /// <param name="className">The name of the class to be removed</param>
        public static void RemoveClass(this ElementReference element, string className)
        {
            _elementHelpersModulesInProcess.InvokeVoid("removeClass", element, className);
        }

        /// <summary>
        /// Removes a class to the given element
        /// </summary>
        /// <param name="element">The element whose class is to be removed</param>
        /// <param name="className">The name of the class to be removed</param>
        public static async Task RemoveClassAsync(this ElementReference element, string className)
        {
            await _elementHelpersModule.InvokeVoidAsync("removeClass", element, className);
        }
    }
}
