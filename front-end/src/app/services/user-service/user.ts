export class User {

    private _userName :string;
    constructor(public userId: number, private firstName: string, private lastName: string) {
        this._userName = `${this.firstName} - ${this.lastName}`;
    }

    public get UserName(): string {
        return this._userName;
    }
    
    
}
