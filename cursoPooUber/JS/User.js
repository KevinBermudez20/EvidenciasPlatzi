class User extends Account{
    constructor(name, document, email, password){
        super(name, document, email, password)
    }

    printDataDriver(){
        console.log(`nombre ${this.name}
         Document ${this.document}`)
    }
}