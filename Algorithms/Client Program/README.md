# Client app

## User identification
1. Registration
   - Ask for e-mail (not necessary, used for password reset)
     * Make sure it's email like ("example@domain.TLD")
   - Ask for username
     * Make sure input only contains numbers and letters from the english alphabet
     * Program sends request to the server right away to check if there's an existing entry in the database for the given username
   - Ask for password (!!! Think of something safe, Mr. Programmers !!!)
     * Hash password with SHA256 right away
2. Login
   - Ask for username
   - Ask for password
   - Package them to a packet, secure the packet, send it to server for user login action
3. Password reset
   - Ask for username
   - Ask for e-mail address
   - Package them to a packet, secure the packet, send it to server for password reset request action
   - Make user check their e-mail for verification code
   - Ask for verification code
   - Ask for new password, and confirm it by asking for it again, hash it via SHA256 right away
   - Package them to a packet, secure the packet, send it to server for password reset action

## Menu