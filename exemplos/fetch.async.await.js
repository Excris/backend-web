// fectch.async.awaint.js

async function verPosts(){
    await fetch("https://jsonplaceholder.typicode.com/posts")
    .then(Response => console.log(Response))
    .then(Response => Response.json)
    .then(data => console(data))

}

verPosts()