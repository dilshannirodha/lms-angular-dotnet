import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-notifications',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './notification.component.html'
})
export class NotificationsComponent {
  notifications = [
    { type: 'Assignment', message: 'New assignment uploaded for Subject 1', date: '2025-06-05' },
    { type: 'Exam', message: 'Midterm exam scheduled for Subject 2 on June 10', date: '2025-06-04' },
    { type: 'Notice', message: 'Library will be closed this weekend', date: '2025-06-03' },
    { type: 'Assignment', message: 'Submit lab report for Subject 3 by Friday', date: '2025-06-02' }
  ];
}
