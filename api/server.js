const express = require('express');
const cors = require('cors');
const bodyParser = require('body-parser');
const fs = require('fs');
const path = require('path');

const app = express();
const DATA_FILE = path.join(__dirname, 'data.json');

app.use(cors());
app.use(bodyParser.json());

// --- Funções utilitárias ---
function loadData() {
    try {
        return JSON.parse(fs.readFileSync(DATA_FILE, 'utf8'));
    } catch {
        return { alunos: [] };
    }
}

function saveData(data) {
    fs.writeFileSync(DATA_FILE, JSON.stringify(data, null, 2));
}

function nextId(items) {
    return items.length ? Math.max(...items.map(i => i.id)) + 1 : 1;
}

// --- ROTAS ---
// GET
app.get('/alunos', (req, res) => {
    const db = loadData();
    res.json(db.alunos);
});

// GET aluno por ID
app.get('/alunos/:id', (req, res) => {
    const db = loadData();
    const id = Number(req.params.id);
    const aluno = db.alunos.find(a => a.id === id);
    if (!aluno) return res.status(404).json({ error: 'Aluno não encontrado' });
    res.json(aluno);
});


// GET aluno por NOME
// GET aluno por NOME
app.get('/alunos/nome/:name', (req, res) => {
    const db = loadData();
    const name = req.params.name.toLowerCase();
    const aluno = db.alunos.find(a => a.name.toLowerCase() === name);
    if (!aluno) return res.status(404).json({ error: 'Aluno não encontrado' });
    res.json(aluno);
});

// POST
app.post('/alunos', (req, res) => {
    const db = loadData();
    const aluno = req.body;
    if (!aluno.name || !aluno.email) {
        return res.status(400).json({ error: 'Nome e email são obrigatórios' });
    }
    aluno.id = nextId(db.alunos);
    db.alunos.push(aluno);
    saveData(db);
    res.status(201).json(aluno);
});

// PUT (substituir todo o aluno)
app.put('/alunos/:id', (req, res) => {
    const db = loadData();
    const id = Number(req.params.id);
    const index = db.alunos.findIndex(a => a.id === id);
    if (index === -1) return res.status(404).json({ error: 'Aluno não encontrado' });

    const aluno = req.body;
    if (!aluno.name || !aluno.email) {
        return res.status(400).json({ error: 'Nome e email são obrigatórios' });
    }

    aluno.id = id;
    db.alunos[index] = aluno;
    saveData(db);
    res.json(aluno);
});

// PATCH (atualização parcial)
app.patch('/alunos/:id', (req, res) => {
    const db = loadData();
    const id = Number(req.params.id);
    const aluno = db.alunos.find(a => a.id === id);
    if (!aluno) return res.status(404).json({ error: 'Aluno não encontrado' });

    if (req.body.name !== undefined) aluno.name = req.body.name;
    if (req.body.email !== undefined) aluno.email = req.body.email;

    saveData(db);
    res.json(aluno);
});

// DELETE
app.delete('/alunos/:id', (req, res) => {
    const db = loadData();
    const id = Number(req.params.id);
    const index = db.alunos.findIndex(a => a.id === id);
    if (index === -1) return res.status(404).json({ error: 'Aluno não encontrado' });

    const removed = db.alunos.splice(index, 1)[0];
    saveData(db);
    res.json({ deleted: removed });
});

// iniciar servidor
const PORT = 3000;
app.listen(PORT, () => console.log(`Servidor rodando em http://localhost:${PORT}`));
