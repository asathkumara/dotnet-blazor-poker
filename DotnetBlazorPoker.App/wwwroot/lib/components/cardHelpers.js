/**
 * Sets the brightness filter on the given card element
 * @param {any} cardElement The card element on which the filter is to be set
 * @param {any} filterIntensity The intensity of the filter [0 - 1]. Defaults to 0.8.
 */
const setBrightnessFilter = (cardElement, filterIntensity = 0.8) => {
    cardElement.style.filter = `brightness(${filterIntensity})`;
};

/**
 * Resets the filter on the given card element
 * @param {any} cardElement The card element where the filters are to be reset
 */
const resetFilter = (cardElement) => {
    cardElement.style.filter = "none";
};

/**
 * Sets the cursor to a pointer on the given card element
 * @param {any} cardElement The card element on which the cursor is to be set to a pointer
 */
const setPointer = (cardElement) => {
    cardElement.style.cursor = "pointer";
}

export { setBrightnessFilter, resetFilter, setPointer };