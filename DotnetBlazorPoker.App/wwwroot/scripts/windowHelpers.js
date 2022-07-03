/**
 * Determine whether the document matches the given media query string.
 * @param {any} mediaQuery
 * @returns True if the query matches; False otherwise.
 */
const matchMedia = (mediaQuery) => {
    return window.matchMedia(mediaQuery).matches;
}

export {
    matchMedia
}