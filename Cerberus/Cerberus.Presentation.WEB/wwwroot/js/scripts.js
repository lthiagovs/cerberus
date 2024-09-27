// scripts.js
document.addEventListener("DOMContentLoaded", function () {
    const words = ["Versatility", "Stealth", "Efficiency"];
    let wordIndex = 0;
    let charIndex = 0;
    let currentWord = '';
    const typingSpeed = 150; // Velocidade de digitação
    const erasingSpeed = 100; // Velocidade de apagamento
    const delayBetweenWords = 1000; // Atraso antes de apagar a palavra
    const typedOutput = document.getElementById("typed-output");
    const cursor = document.querySelector(".cursor");

    function type() {
        if (charIndex < words[wordIndex].length) {
            currentWord += words[wordIndex].charAt(charIndex);
            typedOutput.textContent = currentWord;
            charIndex++;
            setTimeout(type, typingSpeed);
        } else {
            setTimeout(erase, delayBetweenWords);
        }
    }

    function erase() {
        if (charIndex > 0) {
            currentWord = currentWord.substring(0, currentWord.length - 1);
            typedOutput.textContent = currentWord;
            charIndex--;
            setTimeout(erase, erasingSpeed);
        } else {
            wordIndex = (wordIndex + 1) % words.length; // Alterna entre as palavras
            setTimeout(type, typingSpeed);
        }
    }

    // Iniciar a primeira palavra
    type();
});

