describe('Login', function () {
    it('deve acessar a home depois de logado', function () {

        browser.get('');

        expect(browser.getTitle()).toEqual('Home Page - AMESC');
    });
});