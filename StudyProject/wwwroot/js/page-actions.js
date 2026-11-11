// ==============================================
//  page-actions.js - Handles generalized client-side interactions
// ==============================================

//jQuery(document).ready(function($) {
  //$(document).on('click', '.button', function(event) {

    ////if (clickedElement) {
        //const $button = $(this);
        //// 1. Determine the ID: Find the closest parent <tr> and grab the data-char-id attribute.
        //const $triggerRow = $button.closest('tr');
        //const characterId = $triggerRow.data('char-id');

      //freezePage()
      //console.log(characterId)
      //setTimeout(function() {unfreezePage()}, 2000)
      //$.ajax({
            ////url: '/Characters/Details/' + characterId,
            //url: '@Url.Action("Detail", "Characters")/' + characterId,
            //type: 'GET',
            //dataType: 'html', // We expect raw HTML content back
            //success: function (htmlContent) {
                //// 4. DOM Injection: Find the row that was clicked and append the content below it.
                //var $triggerRow = $button.closest('tr');

                //// Wrap the content in a container for better structure/styling
                //var fullHtml = '<div class="char-detail-container card mt-3 p-3" id="details-' + characterId + '">' + htmlContent + '</div>';

                //// Inject the generated content immediately after the row that triggered the action
                //$triggerRow.after(fullHtml);

            //},
            //error: function (xhr, status, error) {
                //console.error("AJAX Error fetching details:", status, error);
                //// Re-enable the button on failure
                //$button.prop('disabled', false).text('Details Button');
                //alert('Failed to load character details. Please check the server logs.');
            //},
            //complete: function () {
                //// Re-enable the button regardless of success or failure
                //$button.prop('disabled', false).text('View Details');
            //}
        //});
  //});

//});
document.addEventListener('DOMContentLoaded', function () {
    document.body.addEventListener('click', async function (event) {
        const targetButton = event.target;

        // Детали
        if (targetButton.className === 'details-btn btn btn-info btn-sm w-45') {
            const charId = targetButton.id;
            if (!charId) {
                console.error("Could not find Character ID from the clicked button.");
                return;
            }

            const parent = targetButton.parentNode;
            const existingDetails = parent.querySelector('.p-3.mt-2.mb-3.border.rounded.bg-light');
            if (existingDetails) {
                existingDetails.remove();
                return;
            }

            targetButton.disabled = true;
            targetButton.textContent = 'Fetching...';

            const detailsUrl = `/Characters/GetDetails/${charId}`;

            // ASYNC
            freezePage();
            const promise1 = fetch(detailsUrl);
            console.log(promise1);
            const promise2 = promise1.then(response => {
                if (!response.ok) {
                    throw new Error(`HTTP error! status: ${response.status}`);
                }
                return response.json();
            });
            const promise3 = promise2.then(data => {
                const detailsContainer = document.createElement('div');
                detailsContainer.className = 'p-3 mt-2 mb-3 border rounded bg-light';

                detailsContainer.innerHTML = `
                    <p class="mt-2"><strong>Description:</strong> ${data.description}</p>
                `;
                targetButton.parentNode.insertBefore(detailsContainer, targetButton.nextSibling);
            });
            console.log(promise3);
            const response = promise3.then(() => {
                targetButton.disabled = false;
                targetButton.textContent = 'Details'; // Reset button text
            });
            console.log(response);
            unfreezePage();
        }

        // Редактирование
        if (targetButton.className === 'edit-btn btn-open-modal btn btn-primary btn-sm w-45') {
            const charId = targetButton.id;
            if (!charId) {
                console.error("Could not find Character ID from the clicked button.");
                return;
            }

            targetButton.disabled = true;
            const originalText = targetButton.textContent;
            targetButton.textContent = 'Loading...';

            const url = `/Characters/PartialEditor/${charId}`;

            try {
                const response = await fetch(url);
                if (!response.ok) {
                    throw new Error(`HTTP error! status: ${response.status}`);
                }
                const html = await response.text();

                const wrapper = document.createElement('div');
                wrapper.innerHTML = html.trim();

                const modalEl = wrapper.firstElementChild;
                document.body.appendChild(modalEl);

                const modal = new bootstrap.Modal(modalEl);
                modal.show();

                modalEl.addEventListener('hidden.bs.modal', function () {
                    modal.dispose();
                    modalEl.remove();
                }, { once: true });
            } catch (error) {
                console.error('Ошибка при загрузке модального окна:', error);
            } finally {
                targetButton.disabled = false;
                targetButton.textContent = originalText;
            }
        }
    });
});


function freezePage() {
    // 1. Clean up any previous overlay
    const existingOverlay = document.getElementById('popup-overlay');
    if (existingOverlay) {
        existingOverlay.remove();
    }

    let overlay = document.createElement('div');
    overlay.id = 'popup-overlay';
    overlay.style.cssText = `
        position: fixed;
        top: 0;
        left: 0;
        width: 100vw;
        height: 100vh;
        z-index: 1000;
        background-color: rgba(0, 0, 0, 0.5);
    `;
    document.body.appendChild(overlay);
}

function unfreezePage() {
    // 1. Reset body styles
    document.body.style.overflow = 'unset';
    document.body.style.position = 'static';
    document.body.style.userSelect = 'auto';

    // 2. Remove the overlay element
    const overlay = document.getElementById('popup-overlay');
    if (overlay) {
        overlay.remove();
    }
}
