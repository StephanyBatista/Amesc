// spec.js
//http://www.protractortest.org/#/tutorial
//https://medium.com/@marcelmokos/end-to-end-testing-with-protractor-using-modern-javascript-syntax-44e5121c2e03
describe('Protractor Demo App', function () {
    it('should have a title', function () {

        browser.ignoreSynchronization = true;

        browser.get('http://localhost:50643/Autenticacao');

        const email = 'fulano@fulano.com';
        const password = '123456';

        element(by.css('[name="Email"]')).sendKeys(email);
        element(by.css('[name="Password"]')).sendKeys(password);

        element(by.css('.btn-default')).click();

        expect(browser.getTitle()).toEqual('Super Calculator');
    });
});