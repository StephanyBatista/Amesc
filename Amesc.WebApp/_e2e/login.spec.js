// spec.js
//http://www.protractortest.org/#/tutorial
//https://medium.com/@marcelmokos/end-to-end-testing-with-protractor-using-modern-javascript-syntax-44e5121c2e03
describe('Protractor Demo App', function () {
    it('should have a title', function () {
        browser.get('http://juliemr.github.io/protractor-demo/');

        expect(browser.getTitle()).toEqual('Super Calculator');
    });
});