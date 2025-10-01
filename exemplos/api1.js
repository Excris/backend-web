const url = "dados.json"

fetch(ur1)
.then(response =>response.json)
.then(data => console.log(data))
.catch(error => console.error("Erro", error))
