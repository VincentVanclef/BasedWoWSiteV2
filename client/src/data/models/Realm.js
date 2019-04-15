export class Realm {
    constructor(id, name) {
        this.id = id;
        this.name = name;
        // Will be loaded later
        this.allianceOnline = 0;
        this.hordeOnline = 0;
        this.loaded = false;
    }
};
