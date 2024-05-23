const contentDiv = document.getElementById("allFitnesses");
const button = document.getElementById("refresh");

function getFitnesses() {
    fetch("https://localhost:5001/api/Fitnesses",
        {
            method: "GET",
            headers: {
                "Accept": "application/json"
            }
        })
        .then(response => {
            if (response.status === 200) {
                return response.json()
            } else {
                document.getElementById("allFitnesses")
                    .innerHTML = "<em>Problem!!!</em>"
            }
        })
        .then(fitnesses => {
            let table = `
        <table class="table">
            <thead>
                <tr><th>Id</th><th>Name</th><th>Address</th><th>Surface</th></tr>
            </thead>
            <tbody>
        `;
            for (const fitness of fitnesses) {
                table += `
                <tr><td>${fitness.id}</td><td>${fitness.name}</td><td>${fitness.address}</td><td>${fitness.surface}m²</td>`
            }
            table += `</tbody></table>`;
            contentDiv.innerHTML = table;
        })
        .catch(error => {
            console.log(error)
        });
}

getFitnesses();

button.addEventListener("click", getFitnesses);