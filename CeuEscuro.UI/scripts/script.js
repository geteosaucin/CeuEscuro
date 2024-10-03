//dropdown


$(function () {
    // Esta linha envolve o código em uma função que será executada quando o DOM estiver pronto.
    
    $('.navbar li ul').hover(
        // Esta linha seleciona todos os itens de lista dentro de um elemento com a classe 'navbar' e aplica o efeito de hover a eles.

        function () {
            // Esta é a função de manipulação que será executada quando o mouse entrar no elemento.
            $('>ul.sub:not(:animated)', this).slideDown(500);
            // Isso seleciona a lista de subitens imediatamente abaixo do item de lista atual e a faz deslizar para baixo com uma duração de 500 milissegundos.
        },
        function () {
            // Esta é a função de manipulação que será executada quando o mouse sair do elemento.
            $('>ul.sub', this).slideUp(300);
            // Isso seleciona a lista de subitens imediatamente abaixo do item de lista atual e a faz deslizar para cima com uma duração de 300 milissegundos.
        }
    );
});