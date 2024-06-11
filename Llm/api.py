from flask import Flask, request, jsonify
from model import gpt_response

app = Flask(__name__)


@app.route('/api/generate', methods=['POST'])
def generate():
    data = request.json
    context = data.get('context')
    query = data.get('query')
    response = gpt_response(context, query)
    return jsonify({'response': response})


if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5001)
