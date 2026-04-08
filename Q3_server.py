import socket
import sqlite3
import json
import uuid
import threading
import logging

logging.basicConfig(level=logging.INFO, format='[%(asctime)s] %(message)s')

HOST = '127.0.0.1'
PORT = 5000


def init_db():
    conn = sqlite3.connect("easydrive.db")
    cursor = conn.cursor()
    cursor.execute("""
    CREATE TABLE IF NOT EXISTS customers (
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        reg_number TEXT UNIQUE,
        name TEXT,
        address TEXT,
        ppsn TEXT,
        license TEXT,
        created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
    )
    """)
    conn.commit()
    conn.close()

def insert_customer(data):
    conn = sqlite3.connect("easydrive.db")
    cursor = conn.cursor()

    reg_number = str(uuid.uuid4())[:8]  

    cursor.execute("""
    INSERT INTO customers (reg_number, name, address, ppsn, license)
    VALUES (?, ?, ?, ?, ?)
    """, (
        reg_number,
        data['name'],
        data['address'],
        data['ppsn'],
        data['license']
    ))

    conn.commit()
    conn.close()
    return reg_number

def validate(data):
    required_fields = ["name", "address", "ppsn", "license"]
    for field in required_fields:
        if field not in data or not data[field].strip():
            return False
    if len(data["ppsn"]) < 5:
        return False
    return True

def handle_client(client_socket, addr):
    logging.info(f"Connected to {addr}")
    try:
        data = client_socket.recv(4096).decode()
        if not data:
            return

        customer = json.loads(data)

        if not validate(customer):
            response = {"status": "error", "message": "Invalid input"}
            client_socket.send(json.dumps(response).encode())
            return

        reg_number = insert_customer(customer)

        response = {"status": "success", "reg_number": reg_number}
        client_socket.send(json.dumps(response).encode())
        logging.info(f"User registered: {reg_number}")

    except Exception as e:
        logging.error(f"Error: {e}")
        response = {"status": "error", "message": "Server error"}
        client_socket.send(json.dumps(response).encode())
    finally:
        client_socket.close()
        logging.info(f"Connection closed: {addr}")

def start_server():
    init_db()
    server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server.bind((HOST, PORT))
    server.listen(5)
    logging.info("Server started. Waiting for connections...")

    while True:
        client_socket, addr = server.accept()
        thread = threading.Thread(target=handle_client, args=(client_socket, addr))
        thread.start()

if __name__ == "__main__":
    start_server()
