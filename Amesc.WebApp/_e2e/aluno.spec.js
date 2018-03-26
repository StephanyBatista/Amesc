'use strict';

const AlunoPo = require("./aluno.po");

describe('aluno', function () {
    
    const data = new Date();
    const nomeDoAluno =  `Protractor Test ${data.getMilliseconds()}`;
    
    it('deve acessar cadastro do aluno', function () {

        browser.get('Alunos');

        expect(browser.getTitle()).toEqual('Alunos - AMESC');
    });

    it('deve cadastrar um novo aluno', function () {

        const alunoPage = new AlunoPo();

        alunoPage.navigateTo('Alunos/Novo');
        alunoPage.sendKeys("Nome", nomeDoAluno);
        alunoPage.sendKeys("Cpf", '00000000001');
        alunoPage.sendKeys("Rg", '00000001');
        alunoPage.sendKeys("OrgaoEmissorDoRg", 'SSP/MS');
        alunoPage.focus("DataDeNascimento");
        alunoPage.sendKeys("DataDeNascimento", '25111985');
        alunoPage.sendKeys("Telefone", '67992992992');
        alunoPage.sendKeys("Logradouro", 'Dua das Garças');
        alunoPage.sendKeys("Numero", '29');
        alunoPage.sendKeys("Bairro", 'Mata do Jacinto');
        alunoPage.sendKeys("Cidade", 'Campo Grande');
        alunoPage.focus("Cep");
        alunoPage.sendKeys("Cep", '79033333');
        alunoPage.submit();

        browser.sleep(3000);

        const alunoCadastrado = element(by.cssContainingText('td', nomeDoAluno));
        
        expect(alunoCadastrado.isDisplayed()).toBeTruthy();
    });

    fit('deve avisar cpf já cadastrado', function() {
        const alunoPage = new AlunoPo();

        alunoPage.navigateTo('Alunos/Novo');

        alunoPage.focus("Cpf");

        alunoPage.sendKeys("Cpf", '00000000001');

        alunoPage.focus("DataDeNascimento");

        browser.sleep(3000);

        browser.wait(function() {

        });

        const cpfCadastrado = element(by.cssContainingText('span', 'CPF Já Cadastrado'));

        expect(cpfCadastrado.isDisplayed()).toBeTruthy();
    });
});