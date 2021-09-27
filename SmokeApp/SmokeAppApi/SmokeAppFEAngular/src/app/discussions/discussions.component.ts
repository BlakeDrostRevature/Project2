import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-discussions',
  templateUrl: './discussions.component.html',
  styleUrls: ['./discussions.component.css']
})
export class DiscussionsComponent implements OnInit {

  constructor() {
    this.getDiscussions();

  }

  ngOnInit(): void {
  }


  discussions =
    [
      {
        title: "Thread 1",
        author: "Cory",
        date: Date.now(),
        commentcount: "4"
      },

      {
        title: "Thread ",
        author: "Jason",
        date: Date.now(),
        commentcount: "4"
      }
    ];


  getDiscussions() {
    var container = document.querySelector('ol')

    for (var discussion of this.discussions) {
      var html: string = `
      <li class="row">
    <a href="thread">
      <h3 class="title">${discussion.title}</h3>
      <div class="bottom">
        <p class="timestamp">
          ${new Date(discussion.date).toLocaleString}
        </p>
        <p class="comment-count">
          ${discussion.commentcount}
        </p>
      </div>
    </a>
  </li>`
      container?.insertAdjacentHTML('beforeend', html)
    };
  }


}
