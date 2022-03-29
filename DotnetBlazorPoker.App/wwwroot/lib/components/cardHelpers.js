const setBrightnessFilter = (cardElement, filterIntensity=0.8) => {
    cardElement.style.filter = `brightness(${filterIntensity})`;
};

const resetFilter = (cardElement) => {
    cardElement.style.filter = "none";
};


const setPointer = (cardElement) => {
    cardElement.style.cursor = "pointer";
}

export { setBrightnessFilter, resetFilter, setPointer };