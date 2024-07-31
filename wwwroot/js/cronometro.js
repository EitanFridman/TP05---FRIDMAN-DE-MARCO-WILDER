let tiempoRestante = parseInt(localStorage.getItem('tiempoRestante')) || 10 * 60;
let intervalo;

function activarCronometro() {
    const cronometroElemento = document.getElementById('timer-display');

    intervalo = setInterval(function () {
        if (tiempoRestante <= 0) {
            clearInterval(intervalo);
            mostrarPopupDerrota();
        } else {
            tiempoRestante--;
            localStorage.setItem('tiempoRestante', tiempoRestante);
            actualizarCronometro(cronometroElemento, tiempoRestante);
        }
    }, 1000);
}

function actualizarCronometro(elemento, tiempo) {
    const minutos = Math.floor(tiempo / 60);
    const segundos = tiempo % 60;
    elemento.textContent = `${formatearTiempo(minutos)}:${formatearTiempo(segundos)}`;
}

function formatearTiempo(tiempo) {
    return tiempo < 10 ? `0${tiempo}` : tiempo;
}

function mostrarPopupDerrota() {
    const popup = document.createElement('div');
    popup.classList.add('popup-derrota');
    popup.innerHTML = `
        <div class="popup-contenido">
            <h2>UUPPPS, HAS PERDIDO... INTÉNTALO NUEVAMENTE</h2>
            <button onclick="window.location.href = urlMenuPrincipal">Volver al Menú Principal</button>
        </div>
    `;
    document.body.appendChild(popup);
}

function iniciarJuego(urlComenzar) {
    localStorage.setItem('juegoIniciado', 'true');
    window.location.href = urlComenzar;
}

document.addEventListener('DOMContentLoaded', function () {
    if (localStorage.getItem('juegoIniciado') === 'true') {
        activarCronometro();
    }
});

function reiniciarJuego() {
    localStorage.setItem('tiempoRestante', 10 * 60);
    localStorage.setItem('juegoIniciado', 'false');
    window.location.href = reiniciarUrl;
}