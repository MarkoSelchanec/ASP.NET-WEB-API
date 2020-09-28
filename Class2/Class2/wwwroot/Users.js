let getAllUsersBtn = document.getElementById("get-users");

let firstNameInput = document.getElementById("firstName-input");
let lastNameInput = document.getElementById("lastName-input");
let postNewUserBtn = document.getElementById("add-user");

let printUsers = document.getElementById("print-users");

let port = "50538";

let getAllUsers = async () => {
    let url = "http://localhost:" + port + "/api/users/list";

    let response = await fetch(url);
    let data = await response.json();
    printUsers.innerHTML = "";
    for (var i = 0; i < data.length; i++) {
        
        let li = document.createElement("li")
        li.append(`${data[i].firstName} ${data[i].lastName}`)
        printUsers.appendChild(li)
    }
    console.log(data)
}

let addNewUser = async () => {
    let url = "http://localhost:" + port + "/api/users/create";

    let user = { firstName: firstNameInput.value, lastName: lastNameInput.value }
    let response = await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    })
    console.log(response)
}

getAllUsersBtn.addEventListener("click", getAllUsers);
postNewUserBtn.addEventListener("click", addNewUser);