import { Course } from "./course";
import { Group } from "./group";
import { Organisation } from "./organisation";

export interface Learner {
    userId: number;
    username: string;
    firstname: string;
    lastname: string;
    group: Group;
    orgaanisation: Organisation;
    courses: Course[];
}