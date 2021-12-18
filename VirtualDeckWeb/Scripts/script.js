function previsualizarImagen(inp) {
	let fichero = inp.files[0];
	if (fichero != null) {
		document.getElementById("hiddenInput").value = '0';
		let fr = new FileReader();

		fr.onload = function () {
			inp.parentNode.querySelector('img').src = fr.result;
		};
		fr.readAsDataURL(fichero);
	} else {
		return;
	}
}

function cargarImagen(dv) {
	dv.querySelector('input[type="file"]').click();
	return false;
}

function borrarFoto(dv) {
	dv.querySelector('img').src = "/Resources/usuario.png";
	dv.querySelector('input[type="file"]').value = '';
	dv.querySelector('input[type="hidden"]').value = '1';
	return false;
}

// ------------------------------- CARLO -----------------------------------

function changeTokens(input) {
	let price = parseInt(document.querySelector('.price').textContent);
	let amount = parseInt(input.value);
	let total = price * amount;
	document.querySelector('.totalPrice').innerText = total;
	return false;
}