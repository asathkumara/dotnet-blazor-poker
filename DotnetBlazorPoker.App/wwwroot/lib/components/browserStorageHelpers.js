const saveData = (key, value) => {
    localStorage.setItem(key, value);
}

const getData = (key) => {
    return localStorage.getItem(key);
}