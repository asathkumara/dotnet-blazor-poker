console.log("Wtf");

const getElementByID = (id) => {
    return document.getElementById(id);
}

const getElementBySelector = (selector) => {
    return document.querySelector(selector);
}

const getElementsBySelector = (selector) => {
    return document.querySelectorAll(selector);
}

const getProperty = (element, property) => {
    return element[property];
}

const setProperty = (element, property, value) => {
    element[property] = value;
}

const getStyle = (element, property) => {
    return element.style[property];
}

const setStyle = (element, property, value) => {
    element.style[property] = value;
}

const addClass = (element, className) => {
    element.classList.add(className);
}

const removeClass = (element, className) => {
    element.classList.remove(className);
}

const setFocus = (element) => {
    element.focus();
}



export {
    getElementByID,
    getElementBySelector,
    getElementsBySelector,
    getProperty,
    getStyle,
    setProperty,
    setStyle,
    setFocus,
    addClass,
    removeClass
}