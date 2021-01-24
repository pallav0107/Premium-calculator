export class OccupationLookup{
    public id: number;
    public occupation: string;    
}

export class CustomerModel{
    public name: string;
    public age: number;
    public dob: Date;
    public occupationId: number;
    public sumInsured: number;
}