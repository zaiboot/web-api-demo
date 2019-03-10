export class User {

    constructor(public id: number, public firstName: string, public lastName: string) {

    }

    public get UserName(): string {

        return `${this.firstName} - ${this.lastName}`;
    }


}
