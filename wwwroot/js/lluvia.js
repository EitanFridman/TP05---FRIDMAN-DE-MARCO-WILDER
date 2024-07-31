document.addEventListener("DOMContentLoaded", () => {
    const rainContainer = document.createElement("div");
    rainContainer.className = "rain-container";
    document.body.appendChild(rainContainer);

    const numNubes = 10;
    const numGotas = 30;

    // Crear las nubes
    for (let i = 0; i < numNubes; i++) {
        const nube = document.createElement("img");
        nube.src = "/img/cloud.svg";
        nube.className = "nube";
        nube.style.left = `${i * 10}%`;
        rainContainer.appendChild(nube);
    }

    // Crear las gotas
    for (let i = 0; i < numGotas; i++) {
        const gota = document.createElement("img");
        gota.src = i % 2 === 0 ? "/img/ball.png" : "/img/shield.png";
        gota.className = "gota";
        gota.style.left = `${Math.random() * 100}%`;
        gota.style.animationDelay = `${Math.random() * 5}s`;
        rainContainer.appendChild(gota);
    }

    // Función para mover las nubes
    const moverNubes = () => {
        const nubes = document.querySelectorAll(".nube");
        nubes.forEach((nube) => {
            let left = parseFloat(nube.style.left);
            left += 0.1;
            if (left > 100) left = -10;
            nube.style.left = `${left}%`;
        });
        requestAnimationFrame(moverNubes);
    };

    moverNubes();
});