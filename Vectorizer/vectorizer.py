from flask import Flask, request, jsonify
from transformers import AutoTokenizer, AutoModel
import torch

app = Flask(__name__)

model_name = "distilbert-base-uncased"
tokenizer = AutoTokenizer.from_pretrained(model_name)
model = AutoModel.from_pretrained(model_name)

documents = []


def vectorize_text(text):
    inputs = tokenizer(text, return_tensors="pt", truncation=True, padding=True, max_length=512)
    outputs = model(**inputs)
    vector = outputs.last_hidden_state.mean(dim=1).squeeze().detach().numpy()
    return vector


@app.route('/api/add_document', methods=['POST'])
def add_document():
    data = request.json
    content = data.get('content')
    vector = vectorize_text(content)
    documents.append({'content': content, 'vector': vector})
    return jsonify({'status': 'Document added successfully'}), 200


@app.route('/api/search', methods=['POST'])
def search():
    data = request.json
    query = data.get('query')
    query_vector = vectorize_text(query)

    similarities = [(doc, torch.nn.functional.cosine_similarity(torch.tensor(query_vector), torch.tensor(doc['vector'])).item()) for doc in documents]
    similarities.sort(key=lambda x: x[1], reverse=True)
    top_documents = [doc for doc, similarity in similarities[:5]]

    return jsonify(top_documents), 200


if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5000)
