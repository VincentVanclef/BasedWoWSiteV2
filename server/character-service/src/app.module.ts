import { Module } from '@nestjs/common';
import { TypeOrmModule } from '@nestjs/typeorm';
import { AppController } from './app.controller';
import { AppService } from './app.service';

import { PostEntity } from './posts/post.entity';
import { PostModule } from './posts/post.module';

@Module({
    imports: [
        TypeOrmModule.forRoot({
            type: 'mysql',
            host: 'localhost',
            port: 3306,
            username: 'api',
            password: 'api123',
            database: 'api',
            entities: [PostEntity],
            synchronize: true,
        }),
        PostModule,
    ],
    controllers: [AppController],
    providers: [AppService],
})
export class AppModule {}
