# Password Encryption Application

A Windows Forms application for encrypting user passwords using SHA-256 hashing algorithm and storing them in both a text file and SQLite database.

## Overview

This application provides a simple user interface for:
- Taking username and password input
- Encrypting passwords using SHA-256 hash
- Displaying the encrypted hash in the application
- Storing user credentials in a text file
- Saving user credentials to an SQLite database

## Features

- **Secure Password Hashing**: Implements SHA-256 cryptographic algorithm to convert passwords into secure hash strings
- **Input Validation**: Ensures password field is not empty before processing
- **Dual Storage**: Saves encrypted credentials to both a text file and SQLite database
- **User-Friendly Interface**: Simple Windows Forms interface with visual feedback

## How It Works

1. The user enters their username and password in the provided text fields
2. Upon clicking the submit button, the application:
   - Validates that the password field isn't empty
   - Encrypts the password using SHA-256 hashing
   - Displays the encrypted hash in the application
   - Saves both username and encrypted password to a text file
   - Stores the credentials in an SQLite database

## Technical Details

### Password Encryption

The application uses the SHA-256 algorithm from the `System.Security.Cryptography` namespace to generate a one-way hash of the password. This provides:
- Fixed-length output (regardless of input length)
- Irreversible encryption (the original password cannot be derived from the hash)
- High collision resistance (different inputs are extremely unlikely to produce the same hash)

### Data Storage

The application stores data in two locations:
1. **Text File**: `C:\Users\spham\OneDrive - UNIVERSITATEA ROMANO-AMERICANA\Apps\App CSE - Currency conversion\encrypt\encrypt.txt`
2. **SQLite Database**: `C:\Users\spham\OneDrive - UNIVERSITATEA ROMANO-AMERICANA\Apps\App CSE - Currency conversion\encrypt\sql for encrypt.db`

## Requirements

- Windows operating system
- .NET Framework (compatible with the version used for development)
- SQLite database engine
- Write permissions to the specified file paths

## Usage

1. Launch the application
2. Enter a username in the username field
3. Enter a password in the password field
4. Click the submit button
5. View the encrypted password displayed in the application
6. Receive confirmation that data has been saved successfully

## Security Considerations

- The application uses one-way hashing, meaning the original password cannot be recovered from the stored hash
- File paths are hardcoded, which may require adjustments for different deployment environments
- Consider implementing additional security measures for production use:
  - Salt for the hash function
  - More secure storage locations
  - Access controls for the database

## Future Improvements

- Add user authentication functionality
- Implement password strength requirements
- Add salt to the hashing process for enhanced security
- Create a configuration file for customizable file paths
- Add user management features (update/delete records)
