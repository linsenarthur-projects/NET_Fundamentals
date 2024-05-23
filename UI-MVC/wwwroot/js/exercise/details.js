const tableBody = document.getElementById("tableBody")
const exerciseIdDiv = document.getElementById("exerciseId")
const exerciseId = parseInt(exerciseIdDiv.innerText)

const addButton = document.getElementById("addMemberToExercise")

const memberId = document.getElementById("memberSelect")
const reps = document.getElementById("reps")
const sets = document.getElementById("sets")

function getMembersData() {
    fetch(`https://localhost:5001/api/exercises/${exerciseId}/members`,
        {
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            }
        })
        .then(response => {
            if (response.status === 200) {
                return response.json()
            } else {
                alert("Problem !")
            }
        })
        .then(members => {
            let bodyData = ``;
            for (const member of members) {
                bodyData += `<tr><td>${member.id}</td><td>${member.name}</td><td>${member.bodyWeight}</td></tr>`
            }
            tableBody.innerHTML = bodyData
        })
        .catch(error => {
            console.log(error)
        });
}

function getAllMembers() {
    fetch("/api/Members",
        {
            headers: {
                "Accept": "application/json"
            }
        })
        .then(response => {
            if (response.status === 200) {
                return response.json()
            } else {
                alert("Problem !")
            }
        })
        .then(members => {
            let selectData = ""
            for (const member of members) {
                selectData += `<option value="${member.id}">${member.name}</option>`
            }
            memberId.innerHTML = selectData
        })
        .catch(error => {
            console.log(error)
        })
}

function addMemberToExercise() {
    const memberExerciseObject = {
        ExerciseId: exerciseId,
        MemberId: memberId.value,
        Reps: reps.value,
        Sets: sets.value
    }
    
    fetch("https://localhost:5001/api/MemberExercises",
        {
            method: "POST",
            body: JSON.stringify(memberExerciseObject),
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            }
        })
        .then(response => {
            if (response.status === 201 || 400) {
                alert("aangemaakt")
                getMembersData()
                getMembersData()
            } else {
                alert(`Received status code ${response.status}. en exerciseId ${exerciseId}, memberId ${memberId.value}, reps ${reps.value}, sets ${sets.value}`)
            }
            return response.json();
        })
        .catch(error => {
            console.log(error)
        });
}

getMembersData();
getAllMembers();
addButton.addEventListener("click", addMemberToExercise);