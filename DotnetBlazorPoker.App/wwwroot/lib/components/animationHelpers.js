/**
 * Increments the value of the given element till it reaches the target value
 * @param {any} element The element whose value is to be increment
 * @param {any} target The target value to be incremented up to
 */
const incrementCounter = (element, target) => {
    let currentValue = +element.innerText;
    let increment = 2;

    if (currentValue < target)
    {
        element.innerText = currentValue + increment;
        setTimeout(() => incrementCounter(element, target), 1);
    }
    else
    {
        element.innerText = target;
    }
}

/**
 * Decrements the value of the given element till it reaches the target value
 * @param {any} element The element whose value is to be decremented
 * @param {any} target The target value to be decremented up to
 */
const decrementCounter = (element, target) => {
    let currentValue = +element.innerText;
    let decrement = 2;

    if (currentValue > target) {
        element.innerText = currentValue - decrement;
        setTimeout(() => decrementCounter(element, target), 1);
    }
    else
    {
        element.innerText = target;
    }
}

export { incrementCounter, decrementCounter };