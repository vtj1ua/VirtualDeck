function SetType(input, value) {
    const typeInput = document.getElementById('type-input');

    let currentValue = parseInt(typeInput.value);

    if (input.checked) {
        currentValue |= value;
    }
    else {
        currentValue &= (~value);
        console.log('asd');
    }

    typeInput.value = currentValue;
}

function SetRarity(input, value) {
    const typeInput = document.getElementById('rarity-input');

    let currentValue = parseInt(typeInput.value);

    if (input.checked) {
        currentValue |= value;
    }
    else {
        currentValue &= (~value);
    }

    typeInput.value = currentValue;
}