import requests


def gpt_response(question, context):
    url = "url-to-gpt"

    data = {
        "messages": [
            {"role": "system", "content": f"{context}"},
            {"role": "user", "content": f"{question}"}
        ]
    }

    response = requests.post(url, json=data)

    if response.status_code == 200:
        response_data = response.json()
        return response_data['response']
    else:
        return f"Error: {response.status_code}, {response.text}"