describe('aluno', function () {
    
    const data = new Date();
    const nomeDoAluno =  `Protractor Test ${data.getMilliseconds()}`;
    
    it('deve acessar cadastro do aluno', function () {

        browser.get('Alunos');

        expect(browser.getTitle()).toEqual('Alunos - AMESC');
    });

    it('deve cadastrar um novo aluno', function () {

        browser.get('Alunos/Novo');
        element(by.css('[name="Nome"]')).sendKeys(nomeDoAluno);
        element(by.css('[name="Cpf"]')).sendKeys('00000000001');
        element(by.css('[name="Rg"]')).sendKeys('00000001');
        element(by.css('[name="OrgaoEmissorDoRg"]')).sendKeys('SSP/MS');
        element(by.css('[name="DataDeNascimento"]')).click('');
        element(by.css('[name="DataDeNascimento"]')).sendKeys('25111985');
        element(by.css('[name="Telefone"]')).click('');
        element(by.css('[name="Telefone"]')).sendKeys('67992992992');
        element(by.css('[name="Logradouro"]')).sendKeys('Dua das Garças');
        element(by.css('[name="Numero"]')).sendKeys('29');
        element(by.css('[name="Bairro"]')).sendKeys('Mata do Jacinto');
        element(by.css('[name="Cidade"]')).sendKeys('Campo Grande');
        element(by.css('[name="Cep"]')).click('');
        element(by.css('[name="Cep"]')).sendKeys('79033333');

        element(by.css('.btn-success')).click();

        const alunoCadastrado = element(by.cssContainingText('td', nomeDoAluno));

        expect(alunoCadastrado.isDisplayed()).toBeTruthy();

        browser.sleep(10000);
    });
});