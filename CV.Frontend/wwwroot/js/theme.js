const btnChangeTheme = document.querySelector('.btn_changetheme');
const root = document.documentElement;

const darkBgrColor = getComputedStyle(root).getPropertyValue('--dark-bgr-color');
const darkTextColor = getComputedStyle(root).getPropertyValue('--dark-text-color');
const darkMainColor = getComputedStyle(root).getPropertyValue('--dark-main-color');

const lightBgrColor = getComputedStyle(root).getPropertyValue('--light-bgr-color');
const lightTextColor = getComputedStyle(root).getPropertyValue('--light-text-color');
const lightMainColor = getComputedStyle(root).getPropertyValue('--light-main-color');

btnChangeTheme.addEventListener('click', () => {
    const currentBgrColor = getComputedStyle(root).getPropertyValue('--dark-bgr-color').trim();

    if (currentBgrColor === darkBgrColor) {
        // Если текущая цветовая схема --dark, переключаем на --light
        root.style.setProperty('--dark-bgr-color', lightBgrColor);
        root.style.setProperty('--dark-text-color', lightTextColor);
        root.style.setProperty('--dark-main-color', lightMainColor);
    } else {
        // Иначе переключаем на --dark
        root.style.setProperty('--dark-bgr-color', darkBgrColor);
        root.style.setProperty('--dark-text-color', darkTextColor);
        root.style.setProperty('--dark-main-color', darkMainColor);
    }
});