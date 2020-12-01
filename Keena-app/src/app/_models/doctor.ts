import { Patient } from './patient';
export interface Doctor {
    
    id: number;
    firstName: string;
    lastName: string;
    gender: boolean;
    address: string;
    email: string;
    phone: string;
    patients:Patient[];
}
