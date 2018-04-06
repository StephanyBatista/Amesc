'use strict';

module.exports = class BasePo {

    constructor() {
        
    }

    navigateTo(url) {
        browser.get(url);
    }

    getBrowser() {
        return browser;
    }

    sendKeys(name, value) {
        element(by.css('[name="' + name + '"]')).sendKeys(value);
    }

    focus(name) {
        element(by.css('[name="' + name + '"]')).click('');
    }

    findElementByText(element, text) {
        return element(by.cssContainingText(element, text));
    }
}