var select;

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
	let total = price;
	if (amount >= 1) {
		if (amount > 50) {
			amount = 50;
			input.value = 50;
		}
		total = price * amount;
	} else {
		input.value = 1;
	}
	document.querySelector('.totalPrice').innerText = total;

	return false;
}


function cambiarActive() {
	let a = window.location.href;
	if (a.includes("VirtualUser/Details")) {
		if (a.includes("page=")) {
			document.getElementById("navUsuarios").getElementsByTagName("li")[0].querySelector("a").click();
		} else if (a.includes("page1=")) {
			document.getElementById("navUsuarios").getElementsByTagName("li")[1].querySelector("a").click();
		}
	}
}