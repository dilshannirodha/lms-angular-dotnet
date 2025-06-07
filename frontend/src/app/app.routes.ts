import { Routes } from '@angular/router';
import { RegisterComponent } from './components/auth/register/register.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AuthGuard } from './components/shared/auth.guard';
import { LoginComponent } from './components/auth/login/login.components';
import { StudentComponent } from './components/student/student.component';
import { SubjectsComponent } from './components/subjects/subjects.component';
import { GradingComponent } from './components/grading/grading.component';
import { FilesComponent } from './components/files/files.component';
import { NotificationsComponent } from './components/notifications/notification.component';
import { TeacherComponent } from './components/teacher/teacher.component';
import { StudentFileComponent } from './components/student-file/student-file.component';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'dashboard', 
    component: DashboardComponent, 
    canActivate: [AuthGuard] ,
    children: [
      { path: 'subjects', component: SubjectsComponent },
      { path: 'grading', component: GradingComponent },
      { path: 'files', component: StudentFileComponent },
      { path: 'notifications', component: NotificationsComponent },
      { path: 'student-details', component: StudentComponent },
      { path: 'teacher-details', component: TeacherComponent },
      { path: 'register', component: RegisterComponent },
    ]},
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: '**', redirectTo: '/dashboard' }
];