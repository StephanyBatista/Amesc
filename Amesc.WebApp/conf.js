'use strict';

module.exports.config = {
    ignoreSynchronization: true,
    framework: 'jasmine',
    seleniumAddress: 'http://localhost:4444/wd/hub',
    baseUrl: 'http://localhost:50644/',
    specs: ['_e2e/*spec.js'],
    onPrepare() {
        browser.ignoreSynchronization = true;

        browser.get('Autenticacao');
        
        const email = 'admin@admin.com';
        const password = '@Axsd12';

        element(by.css('[name="Email"]')).sendKeys(email);
        element(by.css('[name="Password"]')).sendKeys(password);

        element(by.css('.btn-default')).click();
    }
}