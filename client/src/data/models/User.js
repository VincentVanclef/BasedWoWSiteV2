export class User {
    constructor(firstname, lastname, email, token) {
        this.firstName = firstname
        this.lastname = lastname
        this.email = email
        this.token = token
    }

    IsLoggedIn = function() {
        const token = this.token
        if (!token) {
          return false
        }
    
        const data = JSON.parse(atob(token.split(".")[1]))
        const exp = new Date(data.exp * 1000) // JS deals with dates in milliseconds since epoch
        const now = new Date()
        return now < exp
      }
}