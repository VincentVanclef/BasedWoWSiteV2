import { Entity, Column, PrimaryGeneratedColumn } from 'typeorm';

@Entity('post')
export class PostEntity {
    @PrimaryGeneratedColumn()
    public id: number;

    @PrimaryGeneratedColumn('uuid')
    public uuid: string;

    @Column()
    public title: string;

    @Column('text')
    public content: string;

    @Column()
    public type: string;

    // @Column()
    // public createdBy: number;

    @Column()
    public createdAt: string;
}
