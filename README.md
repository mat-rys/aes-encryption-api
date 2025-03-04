# AES Encryption API

A simple API to encrypt and decrypt text using the AES algorithm, along with the ability to generate a Base64-encoded AES key.

## Project Overview

- **Encrypt** and **decrypt** text using a provided AES key.
- **Generate Base64-encoded AES keys** of specific sizes (128, 192, 256 bits).

## Endpoints

### 1. **POST /api/aes/encrypt**
Encrypt text using the AES algorithm with the provided key.

#### Request:

```json
{
  "Plaintext": "Your text to encrypt",
  "Key": "Base64EncodedKey"
}
```

#### Response:

```json
{
  "EncryptedText": "Base64EncryptedText"
}
```

---

### 2. **POST /api/aes/decrypt**
Decrypt AES-encrypted text with the provided key.

#### Request:

```json
{
  "EncryptedText": "Base64EncryptedText",
  "Key": "Base64EncodedKey"
}
```

#### Response:

```json
{
  "Plaintext": "Your decrypted text"
}
```

---

### 3. **GET /api/aes/generateKey/{keySize}**
Generate a Base64-encoded AES key of a specified size (128, 192, 256 bits).

#### Request:
`GET /api/aes/generateKey/{keySize}` (e.g., `/api/aes/generateKey/256`)

#### Response:

```json
{
  "Key": "Base64EncodedKey"
}
```

## How to Use

### cURL Example

- **Encrypting Text**:
  ```bash
  curl -X POST "http://localhost:5000/api/aes/encrypt" -H "Content-Type: application/json" -d '{"Plaintext": "Hello, World!", "Key": "Base64EncodedKey"}'
  ```

- **Decrypting Text**:
  ```bash
  curl -X POST "http://localhost:5000/api/aes/decrypt" -H "Content-Type: application/json" -d '{"EncryptedText": "Base64EncryptedText", "Key": "Base64EncodedKey"}'
  ```

- **Generating AES Key**:
  ```bash
  curl "http://localhost:5000/api/aes/generateKey/256"
  ```

## Installation and Running

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/aes-encryption-api.git
   cd aes-encryption-api
   ```

2. Build and run the project:
   ```bash
   dotnet build
   dotnet run
   ```
