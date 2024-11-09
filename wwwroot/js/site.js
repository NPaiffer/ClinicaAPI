document.addEventListener("DOMContentLoaded", function () {
    const contactForm = document.querySelector("form");

    if (contactForm) {
        contactForm.addEventListener("submit", function (event) {
            event.preventDefault();

            if (contactForm.checkValidity()) {
                alert("Mensagem enviada com sucesso!");
                contactForm.reset();
            } else {
                alert("Por favor, preencha todos os campos obrigatórios.");
            }
        });
    }
});
