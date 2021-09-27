import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-thread',
  templateUrl: './thread.component.html',
  styleUrls: ['./thread.component.css']
})
export class ThreadComponent implements OnInit {

  constructor() {
    console.log(this.threads);
    this.getComment();
  }


  ngOnInit(): void {
  }

  threads =
    [
      {
        title: "Thread 1",
        author: "Cory",
        date: Date.now(),
        content: "Thread Content",
        comments:
          [
            {
              author: "Jack",
              date: Date.now(),
              content: "First!"
            },
            {
              author: "Mike",
              date: Date.now(),
              content: "First!"
            }
          ]
      },

      {
        title: "Thread 2",
        author: "Jason",
        date: Date.now(),
        content: "Thread Content",
        comments:
          [
            {
              author: "Rick",
              date: Date.now(),
              content: "First!"
            },
            {
              author: "Morty",
              date: Date.now(),
              content: "First!"
            }
          ]
      }
    ];
  getMainThread() {

    for (let thread of this.threads) {
      var html =
        `  <div class="main">
          <div class="header">
            <h3 class="title">
              ${thread.title}
            </h3>
            <div class="bottom">
              <p class="timestamp">
              ${new Date(thread.date).toLocaleString}
              </p>
              <p class="commentcount">
                ${thread.comments.length}
              </p>
            </div>
          </div>
          </div>`

    }
  }


  getComment() {
    for (var thread of this.threads) {
      var container = document.querySelector('ol')

      let i = 1;
      var html = `
      <div class="comments">
      <div class="comments">
        <div class="topcomment">
          <p class="user">
            ${thread.comments[i].author}
          </p>
          <p class="comment-ts">
            ${new Date(thread.comments[i].date).toLocaleString}
          </p>
        </div>
        <div class="commentcontent">
        ${thread.comments[i].content}
        </div>
      </div>
    </div>
    };`
      container?.insertAdjacentHTML('beforeend', html)
      i++;
    }
  }




}
