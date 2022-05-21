const uri ='api/brands';
let brands = [];

function getBrands() {
    fetch(uri)
        .then(response => response.json())
.then(data => _displayBrands(data))
.catch (error => console.error('Unable to get brands.', error));
}
function addBrand() {
    const addNameTextbox = document.getElementById('add-name');
    /*const addInfoTextbox = document.getElementById('add-desctiption');*/
    const brand = {
        brandName: addNameTextbox.value.trim()
       /* info: addInfoTextbox.value.trim(),*/
    };
    fetch(uri, {
        method:'POST',
    headers: {'Accept':'application/json',
'Content-Type':'application/json'
    },
    body: JSON.stringify(brand)
})
.then(response => response.json())
.then(() => {
    getBrands();
    addNameTextbox.value ='';
    /*addInfoTextbox.value ='';*/
})
.catch (error => console.error('Unable to add brand.', error));
}

function deleteBrand(id) {
    fetch(`${uri}/${id}`, {
        method:'DELETE'
})
.then(() => getBrands())
.catch (error => console.error('Unable to delete brand.', error));
}
function displayEditForm(id) {
    const brand = brands.find(brand => brand.brandId === id);
    document.getElementById('edit-id').value = brand.brandId;
    document.getElementById('edit-name').value = brand.brandName;
    /*document.getElementById('edit-desctiption').value = brand.info;*/
    document.getElementById('editForm').style.display ='block';
}
function updateBrand() {
        const id = document.getElementById('edit-id').value;
    const brand = {
        brandId: parseInt(id, 10),
        brandName: document.getElementById('edit-name').value.trim()
        //    info: document.getElementById('edit-desctiption').value.trim()
    }
    console.log("------");
    console.log(`${uri}/${id}`);
    console.log(JSON.stringify(brand));
    fetch(`${uri}/${id}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(brand)
    })
        .then(() => getBrands())
        .catch(error => console.error('Unable to update brand.', error));
closeInput();
return false;
}
function closeInput() {
    document.getElementById('editForm').style.display = 'none';

}
function _displayBrands(data) {
    const tBody = document.getElementById('brands');
    tBody.innerHTML ='';
    const button = document.createElement('button');
    data.forEach(brand => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${brand.brandId})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteBrand(${brand.brandId})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);

        let textNode = document.createTextNode(brand.brandName);
        td1.appendChild(textNode);

        //let td2 = tr.insertCell(1);
        //let textNodeInfo = document.createTextNode(brand.desctiption);
        //td2.appendChild(textNodeInfo);

        let td3 = tr.insertCell(1);
        td3.appendChild(editButton);

        let td4 = tr.insertCell(2);
        td4.appendChild(deleteButton);
    });
    brands = data;
}