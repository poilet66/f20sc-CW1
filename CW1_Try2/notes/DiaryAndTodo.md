# Diary

## 24/09/2024
- Made winforms project
- Researched HttpClient class
- Implemented TextBox + HttpClient Request functionality
- Added label denoted status code (+ meaning of code)
- Added history view
## 25/09/2024
- Started work on favourites saving
## 27/09/2024
- Finished favourites handler (still need to add denotation whether entered URL is favourited or not (to allow unfavouriting with same button))

## 04/10/2024
- Started work on history controller. Plan is to cache HTML so it can quickly be re-rendered without re-querying the website in question. Will use list view and map clean name -> full URL
- Looked at using Anchor for resizability

## 05/10/2024
- Cleaned up favourites handler button usability etc. Favourites is completed now. Will begin work on finishing history system

## 19/10/2024
- I think I forgot add a few days worth of entries but its chiiiiill, I've basically finished GUI for history and bulk interaction with history (I should add 'protocol' for bulk too)

# TODO:
- [x] Basic GUI
- [x] HTTP Querying
- [x] Status code indicator
- [x] History view
- [x] Favourites system
- [ ] Bulk download
  - [x] Put history list view in HistoryHandler? 
  - [ ] Button bulk download
  - [ ] Protocol bulk download
- [ ] Initialise university homepage
- [x] History (back/forth arrows + stack impl)
  - [x] Make history view highlight when page is navigated to (through arrows)
  - [x] Fix bug where listview does update when search
- [ ] GUI Tidyup
- [ ] Error Handling
